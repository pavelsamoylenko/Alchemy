using System;

public class ReceiptRequest
{
    public Character Custumer { get; }
    public Receipt Receipt;

    public ReceiptRequest(Character character, Receipt receipt)
    {
        Custumer = character;
        Receipt = receipt;
    }
}