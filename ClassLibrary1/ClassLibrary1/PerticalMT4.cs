using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4DLL
{

    public partial class MT4 : IMT4
{

public double MarketInfo(string symbol, int type)
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "MarketInfo", symbol, type);
}
public int SymbolsTotal(int pos, bool selected)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "SymbolsTotal", pos, selected);
}
public string SymbolName(int pos, bool selected)
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "SymbolName", pos, selected);
}
public bool SymbolSelect(string name, bool select)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "SymbolSelect", name, select);
}

public double AccountInfoDouble(int property_id)
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountInfoDouble", property_id);
}
public long AccountInfoInteger(int property_id)
{
return com.CallMql4<long>(CommunicationMql4.CALL_FUNC, "AccountInfoInteger", property_id);
}
public string AccountInfoString(int property_id)
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "AccountInfoString", property_id);
}
public double AccountBalance()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountBalance");
}
public double AccountCredit()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountCredit");
}
public string AccountCompany()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "AccountCompany");
}
public string AccountCurrency()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "AccountCurrency");
}
public double AccountEquity()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountEquity");
}
public double AccountFreeMargin()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountFreeMargin");
}
public double AccountFreeMarginCheck(string symbol, int cmd, double volume)
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountFreeMarginCheck", symbol, cmd, volume);
}
public double AccountFreeMarginMode()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountFreeMarginMode");
}
public int AccountLeverage()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "AccountLeverage");
}
public double AccountMargin()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountMargin");
}
public string AccountName()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "AccountName");
}
public int AccountNumber()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "AccountNumber");
}
public double AccountProfit()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "AccountProfit");
}
public string AccountServer()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "AccountServer");
}
public int AccountStopoutLevel()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "AccountStopoutLevel");
}
public int AccountStopoutMode()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "AccountStopoutMode");
}

public int GetLastError()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "GetLastError");
}
public bool  IsStopped()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsStopped");
}
public int UninitializeReason()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "UninitializeReason");
}
public int MQLInfoInteger(int property_id)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "MQLInfoInteger", property_id);
}
public string MQLInfoString(int property_id)
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "MQLInfoString", property_id);
}
public void MQLSetInteger(int property_id, int property_value)
{
com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "MQLSetInteger", property_id, property_value);
}
public int TerminalInfoInteger(int property_id)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TerminalInfoInteger", property_id);
}
public double TerminalInfoDouble(double property_id)
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "TerminalInfoDouble", property_id);
}
public string TerminalInfoString(int property_id)
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "TerminalInfoString", property_id);
}
public string Symbol()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "Symbol");
}
public int Period()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Period");
}
public double Point()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Point");
}
public bool  IsConnected()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsConnected");
}
public bool  IsDemo()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsDemo");
}
public bool  IsDllsAllowed()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsDllsAllowed");
}
public bool  IsExpertEnabled()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsExpertEnabled");
}
public bool  IsLibrariesAllowed()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsLibrariesAllowed");
}
public bool  IsOptimization()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsOptimization");
}
public bool  IsTesting()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsTesting");
}
public bool IsTradeAllowed(string symbol, MT4DateTime tested_time)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "IsTradeAllowed", symbol, tested_time);
}
public bool  IsTradeContextBusy()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsTradeContextBusy");
}
public bool  IsVisualMode()
{
return com.CallMql4<bool >(CommunicationMql4.CALL_FUNC, "IsVisualMode");
}
public string TerminalCompany()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "TerminalCompany");
}
public string TerminalName()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "TerminalName");
}
public string TerminalPath()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "TerminalPath");
}

public bool OrderClose(int ticket, double lots, double price, int slippage, MT4Color arrow_color)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "OrderClose", ticket, lots, price, slippage, arrow_color);
}
public bool OrderCloseBy(int ticket, int opposite, MT4Color arrow_color)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "OrderCloseBy", ticket, opposite, arrow_color);
}
public double OrderClosePrice()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderClosePrice");
}
public MT4DateTime OrderCloseTime()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "OrderCloseTime");
}
public string OrderComment()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "OrderComment");
}
public double OrderCommission()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderCommission");
}
public bool OrderDelete(int ticket, MT4Color arrow_color)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "OrderDelete", ticket, arrow_color);
}
public MT4DateTime OrderExpiration()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "OrderExpiration");
}
public double OrderLots()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderLots");
}
public int OrderMagicNumber()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrderMagicNumber");
}
public int OrderModify(int ticket, double price, double stoploss, double takeprofit, MT4DateTime expiration, MT4Color arrow_color)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrderModify", ticket, price, stoploss, takeprofit, expiration, arrow_color);
}
public double OrderOpenPrice()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderOpenPrice");
}
public MT4DateTime OrderOpenTime()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "OrderOpenTime");
}
public void OrderPrint()
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "OrderPrint");
}
public double OrderProfit()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderProfit");
}
public bool OrderSelect(int ticket, int select, int pool)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "OrderSelect", ticket, select, pool);
}
public int OrderSend(string symbol, int cmd, double volume, double price, int slippage, double stoploss, double takeprofit, string comment, int magic, MT4DateTime expiration, MT4Color arrow_color)
{
    return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrderSend", symbol, cmd, volume, price, slippage, stoploss, takeprofit, comment, magic, expiration, arrow_color);
}
public int OrdersHistoryTotal()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrdersHistoryTotal");
}
public double OrderStopLoss()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderStopLoss");
}
public int OrdersTotal()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrdersTotal");
}
public double OrderSwap()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderSwap");
}
public string OrderSymbol()
{
return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "OrderSymbol");
}
public double OrderTakeProfit()
{
return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "OrderTakeProfit");
}
public int OrderTicket()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrderTicket");
}
public int OrderType()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "OrderType");
}

public void Alert()
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "Alert");
}
public void Comment()
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "Comment");
}
public void DebugBreak()
{
com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "DebugBreak");
}
public void ExpertRemove()
{
com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "ExpertRemove");
}
public ulong GetMicrosecondCount()
{
return com.CallMql4<ulong>(CommunicationMql4.CALL_FUNC, "GetMicrosecondCount");
}
public int MessageBox(string text, string caption, int flags)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "MessageBox", text, caption, flags);
}
public bool PlaySound(string filename)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "PlaySound", filename);
}
public void Print()
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "Print");
}
public void PrintFormat(string format_string)
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "PrintFormat", format_string);
}
public void ResetLastError()
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "ResetLastError");
}
public bool ResourceFree(string resource_name)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "ResourceFree", resource_name);
}
public bool ResourceSave(string resource_name, string file_name)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "ResourceSave", resource_name, file_name);
}
public bool SendFTP(string filename, string ftp_path)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "SendFTP", filename, ftp_path);
}
public bool SendMail(string subject, string some_text)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "SendMail", subject, some_text);
}
public bool SendNotification(string text)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "SendNotification", text);
}
public void Sleep(int milliseconds)
{
 com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "Sleep", milliseconds);
}
public bool TerminalClose(int ret_code)
{
return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "TerminalClose", ret_code);
}
public MT4DateTime TimeCurrent()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "TimeCurrent");
}
public MT4DateTime TimeLocal()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "TimeLocal");
}
public MT4DateTime TimeGMT()
{
return com.CallMql4<MT4DateTime>(CommunicationMql4.CALL_FUNC, "TimeGMT");
}
public int TimeDaylightSavings()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeDaylightSavings");
}
public int TimeGMTOffset()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeGMTOffset");
}
public int Day()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Day");
}
public int DayOfWeek()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "DayOfWeek");
}
public int DayOfYear()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "DayOfYear");
}
public int Hour()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Hour");
}
public int Minute()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Minute");
}
public int Month()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Month");
}
public int Seconds()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Seconds");
}
public int TimeDay(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeDay", date);
}
public int TimeDayOfWeek(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeDayOfWeek", date);
}
public int TimeDayOfYear(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeDayOfYear", date);
}
public int TimeHour(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeHour", date);
}
public int TimeMinute(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeMinute", date);
}
public int TimeMonth(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeMonth", date);
}
public int TimeSeconds(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeSeconds", date);
}
public int TimeYear(MT4DateTime date)
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "TimeYear", date);
}
public int Year()
{
return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Year");
}

public int _Digits
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "_Digits");
            }
        }
public double _Point
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "_Point");
            }
        }
public int _LastError
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "_LastError");
            }
        }
public int _Period
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "_Period");
            }
        }
public int _RandomSeed
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "_RandomSeed");
            }
        }
public bool _StopFlag
        {
            get
            {
                return com.CallMql4<bool>(CommunicationMql4.CALL_FUNC, "_StopFlag");
            }
        }
public string _Symbol
        {
            get
            {
                return com.CallMql4<string>(CommunicationMql4.CALL_FUNC, "_Symbol");
            }
        }
public int _UninitReason
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "_UninitReason");
            }
        }
public double Ask
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Ask");
            }
        }
public int Bars
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Bars");
            }
        }
public double Bid
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Bid");
            }
        }
public double Close
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Close");
            }
        }
public int Digits
        {
            get
            {
                return com.CallMql4<int>(CommunicationMql4.CALL_FUNC, "Digits");
            }
        }
public double High
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "High");
            }
        }
public double Low
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Low");
            }
        }
public double Open
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Open");
            }
        }
public double Time
        {
            get
            {
                return com.CallMql4<double>(CommunicationMql4.CALL_FUNC, "Time");
            }
        }
public long Volume
        {
            get
            {
                return com.CallMql4<long>(CommunicationMql4.CALL_FUNC, "Volume");
            }
        }
}
}