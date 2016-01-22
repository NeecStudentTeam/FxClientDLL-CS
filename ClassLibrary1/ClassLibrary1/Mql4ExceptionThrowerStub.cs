/* 
 * CheckError(関数名、実行結果)
 * MT4の関数名とパース後の戻り値からエラーかどうかチェックし、
 * エラーであればCheckErrorExceptionを投げる。
 * Exceptionに回復方法は明記せず、
 * 親メソッドでリソースから取得したエラーメッセージを表示させる。
 * 
 * 
 * 
 * エラーかどうかの判断は以下の手順によって行われる
 * １．エラーデータベース内該当テーブルのメソッド名に対応するidを取得
 * ２．別テーブルのidに対応するエラー結果を取得
 * ３．エラー結果とテーブル内のエラー番号が一致していたらエラーと判断
 * 
 * 
 * 
 * 実行環境
 * sqlite3.exe、Mql4ErrorData.you10をMT4DLLと同じディレクトリへ
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows;
using System.Threading;
using System.Drawing;
using System.Diagnostics;


namespace MT4DLL
{
	class Mql4ExceptionThrowerStub : IMql4ExceptionThrower
	{
		//インナークラスでException持つ
		class CheckErrorException : Exception
		{
			private int errNum;
			public CheckErrorException(int _errNum)
			{
				this.errNum = _errNum;
			}
		}



		/// <summary>
		/// ログ出力
		/// </summary>
		/// <param name="s"></param>
		void WriteLog(string s) { Console.WriteLine("\n/***************\n\n\n' " + s + " ' \n\n\n/****************\n"); }



		/// <summary>
		/// エラー判断
		/// </summary>
		/// <param name="func_name">関数名</param>
		/// <param name="result">結果</param>
		public void CheckError(string func_name, object result)
		{

			List<string> l = new List<string>();							//テーブルの総数
			string src = "Data Source=.\\ClassLibrary1\\sqlite\\sample.you10";			//データベースのソース
			MT4 m = new MT4();

			using (SQLiteConnection cn = new SQLiteConnection(src))
			{

				string hitTableName = "";					//該当テーブル名
				string hitID = "0";							//該当ID

				try
				{
					cn.Open();

					//旧　SQL8(Connection cmd = cn.CreateCommand();どっちでもいける。
					SQLiteCommand cmd = new SQLiteCommand(cn);

					//テーブルの総数,名前を取得
					cmd.CommandText = "select tbl_name from sqlite_master";

					//SQL文をコンソールに出力
					WriteLog(cmd.CommandText);

					using (SQLiteDataReader r = cmd.ExecuteReader())
					{
						while (r.Read())
						{
							l.Add(r["tbl_name"].ToString());
							WriteLog(r["tbl_name"].ToString());
						}
					}

					//取得したテーブル内でfunc_nameに当たる関数がどこにあるか調べる
					for (int i = 0; i <= l.Count - 1; i++)
					{
						//もしファイルがEで終わらなかったら
						if (!(Regex.IsMatch(l[i].ToString(), @"E$")))
						{
							//テーブル内のfunc_name列を探索
							cmd.CommandText = "select * from " + l[i];

							WriteLog(cmd.CommandText);

							using (SQLiteDataReader r = cmd.ExecuteReader())
							{
								while (r.Read())

									//引数と同じ関数名を見つけたらテーブル名を取得
									if (func_name.Equals(r["func_name"].ToString()))
									{
										hitTableName = l[i];
										break;
									}

							}
						}

					}


					WriteLog(hitTableName);

					//該当するテーブルに対応する、別テーブル
					//関数と同じidを持つエラー番号列の中身を選択
					cmd.CommandText = "select * from " + hitTableName + " where func_name = '" + func_name + "'";

					WriteLog(cmd.CommandText);

					//func_nameのidが返ってくるはずなのでオーバーライド時のどれが正しいか戻り値から判断
					//戻り値の型まで同じ場合はエラー番号も同じなのでよしとする
					using (SQLiteDataReader r = cmd.ExecuteReader())
					{

						while (r.Read())
						{

							//もしfunc_typeがresultのタイプと同じだったら
							//if (r["return_type"].ToString().Equals(result.GetType().ToString()))

							//idを取得
							hitID = r["id"].ToString();
							WriteLog(hitID);
						}
						//									System.Windows.("\n\n\n"+r[""].ToString()+"\n\n\n");

					}

					//エラー番号照合用のテーブルからidと一致するエラー番号を取得
					cmd.CommandText = "select * from " + hitTableName + "E where id = '" + hitID + "'";
					WriteLog(cmd.CommandText);

					using (SQLiteDataReader r = cmd.ExecuteReader())
					{
						while (r.Read())
						{
							int errNum;
							//もしエラー番号とresultの値が一致していたら

							WriteLog(r["err_result"].ToString());

							if (r["err_result"].ToString().Equals(result) && result != null)
							{
								if (r["err_result"].ToString().Equals("-1"))
								{
									errNum = 1;
								}
								else
								{
									errNum = 0;
								}

								//GetLastError()で番号を取得後
								errNum = m.GetLastError();

								//Exception投げる
								WriteLog("errNum :" + errNum.ToString());
								throw new CheckErrorException(errNum);
							}
						}
					}

				}
				finally
				{
					cn.Close();
				}
			}
		}
	}
}
