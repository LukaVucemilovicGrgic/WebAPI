using System;

public class BuyerCreateView
{
    public Guid Id { get; set; }
    public string BuyerName { get; set; }
    public int? PersonalIdentificationNumber { get; set; }
    public Guid? TicketId { get; set; }
}