// See https://aka.ms/new-console-template for more information

string senderID = "EPSON";
string termID = "00001";
string message = termID + ":::" + senderID + "+" + "";

var dispay = message.Split('+');
Console.WriteLine(dispay[0]);