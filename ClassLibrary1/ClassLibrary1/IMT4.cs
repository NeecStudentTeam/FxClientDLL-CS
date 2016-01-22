using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{
    public interface IMT4
    {
        int Connect(string server = "127.0.0.1", int port = 9999);

        bool isConnected();

        int Disconnect();

        void Start();

        double MarketInfo(string symbol, int type);
        int SymbolsTotal(int pos, bool selected);
        string SymbolName(int pos, bool selected);
        bool SymbolSelect(string name, bool select);

        double AccountInfoDouble(int property_id);
        long AccountInfoInteger(int property_id);
        string AccountInfoString(int property_id);
        double AccountBalance();
        double AccountCredit();
        string AccountCompany();
        string AccountCurrency();
        double AccountEquity();
        double AccountFreeMargin();
        double AccountFreeMarginCheck(string symbol, int cmd, double volume);
        double AccountFreeMarginMode();
        int AccountLeverage();
        double AccountMargin();
        string AccountName();
        int AccountNumber();
        double AccountProfit();
        string AccountServer();
        int AccountStopoutLevel();
        int AccountStopoutMode();

        int GetLastError();
        bool IsStopped();
        int UninitializeReason();
        int MQLInfoInteger(int property_id);
        string MQLInfoString(int property_id);
        void MQLSetInteger(int property_id, int property_value);
        int TerminalInfoInteger(int property_id);
        double TerminalInfoDouble(double property_id);
        string TerminalInfoString(int property_id);
        string Symbol();
        int Period();
        double Point();
        bool IsConnected();
        bool IsDemo();
        bool IsDllsAllowed();
        bool IsExpertEnabled();
        bool IsLibrariesAllowed();
        bool IsOptimization();
        bool IsTesting();
        bool IsTradeAllowed(string symbol, MT4DateTime tested_time);
        bool IsTradeContextBusy();
        bool IsVisualMode();
        string TerminalCompany();
        string TerminalName();
        string TerminalPath();

        bool OrderClose(int ticket, double lots, double price, int slippage, MT4Color arrow_color);
        bool OrderCloseBy(int ticket, int opposite, MT4Color arrow_color);
        double OrderClosePrice();
        MT4DateTime OrderCloseTime();
        string OrderComment();
        double OrderCommission();
        bool OrderDelete(int ticket, MT4Color arrow_color);
        MT4DateTime OrderExpiration();
        double OrderLots();
        int OrderMagicNumber();
        int OrderModify(int ticket, double price, double stoploss, double takeprofit, MT4DateTime expiration, MT4Color arrow_color);
        double OrderOpenPrice();
        MT4DateTime OrderOpenTime();
        void OrderPrint();
        double OrderProfit();
        bool OrderSelect(int ticket, int select, int pool);
        int OrderSend(string symbol, int cmd, double volume, double price, int slippage, double stoploss, double takeprofit, string comment, int magic, MT4DateTime expiration, MT4Color arrow_color);
        int OrdersHistoryTotal();
        double OrderStopLoss();
        int OrdersTotal();
        double OrderSwap();
        string OrderSymbol();
        double OrderTakeProfit();
        int OrderTicket();
        int OrderType();

        void Alert();
        void Comment();
        void DebugBreak();
        void ExpertRemove();
        ulong GetMicrosecondCount();
        int MessageBox(string text, string caption, int flags);
        bool PlaySound(string filename);
        void Print();
        void PrintFormat(string format_string);
        void ResetLastError();
        bool ResourceFree(string resource_name);
        bool ResourceSave(string resource_name, string file_name);
        bool SendFTP(string filename, string ftp_path);
        bool SendMail(string subject, string some_text);
        bool SendNotification(string text);
        void Sleep(int milliseconds);
        bool TerminalClose(int ret_code);
        MT4DateTime TimeCurrent();
        MT4DateTime TimeLocal();
        MT4DateTime TimeGMT();
        int TimeDaylightSavings();
        int TimeGMTOffset();
        int Day();
        int DayOfWeek();
        int DayOfYear();
        int Hour();
        int Minute();
        int Month();
        int Seconds();
        int TimeDay(MT4DateTime date);
        int TimeDayOfWeek(MT4DateTime date);
        int TimeDayOfYear(MT4DateTime date);
        int TimeHour(MT4DateTime date);
        int TimeMinute(MT4DateTime date);
        int TimeMonth(MT4DateTime date);
        int TimeSeconds(MT4DateTime date);
        int TimeYear(MT4DateTime date);
        int Year();

        int _Digits { get; }
        double _Point { get; }
        int _LastError { get; }
        int _Period { get; }
        int _RandomSeed { get; }
        bool _StopFlag { get; }
        string _Symbol { get; }
        int _UninitReason { get; }
        double Ask { get; }
        int Bars { get; }
        double Bid { get; }
        double Close { get; }
        int Digits { get; }
        double High { get; }
        double Low { get; }
        double Open { get; }
        double Time { get; }
        long Volume { get; }
    }
}
