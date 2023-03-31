using Program.DAL;
using Program.Model;
using Program.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFProgram.Repository
{
    public class EFBuyerRepository : IBuyerRepository
    {
        private readonly BuyerContext _context;

        public EFBuyerRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<List<Program.Model.Buyer>> GetAllBuyersAsync()
        {
            //List<Buyer> buyers = await _context.Buyer.ToListAsync();
            List<Program.Model.Buyer> mappedBuyers = await _context.Buyer.Select(s => new Program.Model.Buyer()
            {
                Id = s.Id,
                BuyerName = s.BuyerName,
                PersonalIdentificationNumber = s.PersonalIdentificationNumber,
                TicketId = s.TicketId
            }).ToListAsync();

            return mappedBuyers;
        }
        public async Task<bool> AddBuyerAsync(Program.Model.Buyer buyer)
        {
            try
            {
                //AddAsync ne postoji 
                _context.Buyer.Add(new Program.DAL.Buyer
                {
                    Id = buyer.Id,
                    BuyerName = buyer.BuyerName,
                    PersonalIdentificationNumber = buyer.PersonalIdentificationNumber,
                    TicketId = buyer.TicketId
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<Program.Model.Buyer>> GetBuyerAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBuyerAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateBuyerAsync(Guid id, Program.Model.Buyer buyer)
        {
            throw new NotImplementedException();
        }
    }
}
