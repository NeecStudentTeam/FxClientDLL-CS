using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    public class MT4Stub : IMT4
    {
        int seed = 0;

        int randMinPer;

        int randMaxPer;

        string stubString = "outputbystub";

        public int Disconnect()
        {
            return 1;
        }

        private class Ticket
        {
            public int ticketNum;
            public double rate;
        }

        double randDouble
        {
            get
            {
                return 50 * getRand();
            }
        }

        public MT4Stub()
        {
        }

        public MT4Stub(int randMinPer, int randMaxPer)
        {
            this.randMaxPer = randMaxPer;
            this.randMinPer = randMinPer;
        }

        int Count = 1;
        public double MarketInfo(string symbol, int type)
        {
            //シンボルでハッシュを計算
            byte[] sourcebyte = System.Text.Encoding.GetEncoding("SHIFT_JIS").GetBytes(symbol);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] md5byte = md5.ComputeHash(sourcebyte);

            int md5hash = BitConverter.ToInt32(md5byte,0);

            double rate = 0;

            if(type == 9)
            {
                rate = 100 * getRand(md5hash);
            }
            else
            {
                rate = 90 * getRand(md5hash);
            }

            double haba = rate * 0.01;

            double habaRate = rate +( Math.Sin(Math.PI * 2 / 500 * Count) * haba);

            Count++;

            double habaRateRound = Math.Round(habaRate, 5, MidpointRounding.AwayFromZero);

            return habaRateRound;


        }

            int _TicketNum = 654321;
           public int OrderSend(string symbol, int cmd, double volume, double price, int slippage, double stoploss, double takeprofit, string comment, int magic, MT4DateTime expiration, MT4Color arrow_color)
            {
                return _TicketNum++;
            }

            double getRand()
            {

                Random rnd = new Random(seed++);

                int rndNum = rnd.Next(990, 1010);

                return rndNum * 0.001;
            }



            double getRand(int seed)
            {

                Random rnd = new Random(seed);

                int rndNum = rnd.Next(990, 1010);

                return rndNum * 0.001;
            }



        public int Connect(string server = "127.0.0.1", int port = 9999)
        {
            return 0;
        }

        public bool isConnected()
        {
            return true;
        }

        public void Start()
        {

        }

        public int SymbolsTotal(int pos, bool selected)
        {
            return 0;
        }

        public string SymbolName(int pos, bool selected)
        {
            return stubString;
        }

        public bool SymbolSelect(string name, bool select)
        {
            return true;
        }

        public double AccountInfoDouble(int property_id)
        {
            return randDouble;
        }

        public long AccountInfoInteger(int property_id)
        {
            return 0;
        }

        public string AccountInfoString(int property_id)
        {
            return stubString;
        }

        public double AccountBalance()
        {
            return randDouble;
        }

        public double AccountCredit()
        {
            return randDouble;
        }

        public string AccountCompany()
        {
            return stubString;
        }

        public string AccountCurrency()
        {
            return stubString;
        }

        public double AccountEquity()
        {
            return randDouble;
        }

        public double AccountFreeMargin()
        {
            return randDouble;
        }

        public double AccountFreeMarginCheck(string symbol, int cmd, double volume)
        {
            return randDouble;
        }

        public double AccountFreeMarginMode()
        {
            return randDouble;
        }

        public int AccountLeverage()
        {
            return 0;
        }

        public double AccountMargin()
        {
            return randDouble;
        }

        public string AccountName()
        {
            return stubString;
        }

        public int AccountNumber()
        {
            return 0;
        }

        public double AccountProfit()
        {
            return randDouble;
        }

        public string AccountServer()
        {
            return stubString;
        }

        public int AccountStopoutLevel()
        {
            return 0;
        }

        public int AccountStopoutMode()
        {
            return 0;
        }

        public int GetLastError()
        {
            return 0;
        }

        public bool IsStopped()
        {
            return false;
        }

        public int UninitializeReason()
        {
            return 0;
        }

        public int MQLInfoInteger(int property_id)
        {
            return 0;
        }

        public string MQLInfoString(int property_id)
        {
            return stubString;
        }

        public void MQLSetInteger(int property_id, int property_value)
        {
        }

        public int TerminalInfoInteger(int property_id)
        {
            return 0;
        }

        public double TerminalInfoDouble(double property_id)
        {
            return randDouble;
        }

        public string TerminalInfoString(int property_id)
        {
            return stubString;
        }

        public string Symbol()
        {
            return stubString;
        }

        public int Period()
        {
            return 0;
        }

        public double Point()
        {
            return randDouble;
        }

        public bool IsConnected()
        {
            return true;
        }

        public bool IsDemo()
        {
            return true;
        }

        public bool IsDllsAllowed()
        {
            return true;
        }

        public bool IsExpertEnabled()
        {
            return true;
        }

        public bool IsLibrariesAllowed()
        {
            return true;
        }

        public bool IsOptimization()
        {
            return true;
        }

        public bool IsTesting()
        {
            return true;
        }

        public bool IsTradeAllowed(string symbol, MT4DateTime tested_time)
        {
            return true;
        }

        public bool IsTradeContextBusy()
        {
            return true;
        }

        public bool IsVisualMode()
        {
            return true;
        }

        public string TerminalCompany()
        {
            return stubString;
        }

        public string TerminalName()
        {
            return stubString;
        }

        public string TerminalPath()
        {
            return stubString;
        }

        public bool OrderClose(int ticket, double lots, double price, int slippage, MT4Color arrow_color)
        {
            return true;
        }

        public bool OrderCloseBy(int ticket, int opposite, MT4Color arrow_color)
        {
            return true;
        }

        public double OrderClosePrice()
        {
            return randDouble;
        }

        public MT4DateTime OrderCloseTime()
        {
            return null;
        }

        public string OrderComment()
        {
            return stubString;
        }

        public double OrderCommission()
        {
            return randDouble;
        }

        public bool OrderDelete(int ticket, MT4Color arrow_color)
        {
            return true;
        }

        public MT4DateTime OrderExpiration()
        {
            return null;
        }

        public double OrderLots()
        {
            return randDouble;
        }

        public int OrderMagicNumber()
        {
            return 0;
        }

        public int OrderModify(int ticket, double price, double stoploss, double takeprofit, MT4DateTime expiration, MT4Color arrow_color)
        {
            return 0;
        }

        public double OrderOpenPrice()
        {
            return randDouble;
        }

        public MT4DateTime OrderOpenTime()
        {
            return null;
        }

        public void OrderPrint()
        {
        }

        public double OrderProfit()
        {
            return randDouble;
        }

        public bool OrderSelect(int ticket, int select, int pool)
        {
            return true;
        }

        public int OrdersHistoryTotal()
        {
            return 0;
        }

        public double OrderStopLoss()
        {
            return randDouble;
        }

        public int OrdersTotal()
        {
            return 0;
        }

        public double OrderSwap()
        {
            return randDouble;
        }

        public string OrderSymbol()
        {
            return stubString;
        }

        public double OrderTakeProfit()
        {
            return randDouble;
        }

        public int OrderTicket()
        {
            return 0;
        }

        public int OrderType()
        {
            return 0;
        }

        public void Alert()
        {
        }

        public void Comment()
        {
        }

        public void DebugBreak()
        {
        }

        public void ExpertRemove()
        {
        }

        public ulong GetMicrosecondCount()
        {
            return 0;
        }

        public int MessageBox(string text, string caption, int flags)
        {
            return 0;
        }

        public bool PlaySound(string filename)
        {
            return true;
        }

        public void Print()
        {
        }

        public void PrintFormat(string format_string)
        {
        }

        public void ResetLastError()
        {
        }

        public bool ResourceFree(string resource_name)
        {
            return true;
        }

        public bool ResourceSave(string resource_name, string file_name)
        {
            return true;
        }

        public bool SendFTP(string filename, string ftp_path)
        {
            return true;
        }

        public bool SendMail(string subject, string some_text)
        {
            return true;
        }

        public bool SendNotification(string text)
        {
            return true;
        }

        public void Sleep(int milliseconds)
        {
        }

        public bool TerminalClose(int ret_code)
        {
            return true;
        }

        public MT4DateTime TimeCurrent()
        {
            return null;
        }

        public MT4DateTime TimeLocal()
        {
            return null;
        }

        public MT4DateTime TimeGMT()
        {
            return null;
        }

        public int TimeDaylightSavings()
        {
            return 0;
        }

        public int TimeGMTOffset()
        {
            return 0;
        }

        public int Day()
        {
            return 0;
        }

        public int DayOfWeek()
        {
            return 0;
        }

        public int DayOfYear()
        {
            return 0;
        }

        public int Hour()
        {
            return 0;
        }

        public int Minute()
        {
            return 0;
        }

        public int Month()
        {
            return 0;
        }

        public int Seconds()
        {
            return 0;
        }

        public int TimeDay(MT4DateTime date)
        {
            return 0;
        }

        public int TimeDayOfWeek(MT4DateTime date)
        {
            return 0;
        }

        public int TimeDayOfYear(MT4DateTime date)
        {
            return 0;
        }

        public int TimeHour(MT4DateTime date)
        {
            return 0;
        }

        public int TimeMinute(MT4DateTime date)
        {
            return 0;
        }

        public int TimeMonth(MT4DateTime date)
        {
            return 0;
        }

        public int TimeSeconds(MT4DateTime date)
        {
            return 0;
        }

        public int TimeYear(MT4DateTime date)
        {
            return 0;
        }

        public int Year()
        {
            return 0;
        }

        public int _Digits
        {
            get { return 0; }
        }

        public double _Point
        {
            get { return 0; }
        }

        public int _LastError
        {
            get { return 0; }
        }

        public int _Period
        {
            get { return 0; }
        }

        public int _RandomSeed
        {
            get { return 0; }
        }

        public bool _StopFlag
        {
            get { return false; }
        }

        public string _Symbol
        {
            get { return stubString; }
        }

        public int _UninitReason
        {
            get { return 0; }
        }

        public double Ask
        {
            get { return 0; }
        }

        public int Bars
        {
            get { return 0; }
        }

        public double Bid
        {
            get { return 0; }
        }

        public double Close
        {
            get { return 0; }
        }

        public int Digits
        {
            get { return 0; }
        }

        public double High
        {
            get { return 0; }
        }

        public double Low
        {
            get { return 0; }
        }

        public double Open
        {
            get { return 0; }
        }

        public double Time
        {
            get { return 0; }
        }

        public long Volume
        {
            get { return 0; }
        }
    }
}
