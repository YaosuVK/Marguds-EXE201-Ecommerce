using BussinessObject.Model;
using DataAccessLayer.BaseDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public class VoucherDAO : BaseDAO<Voucher>
{
    private readonly MargudsContext _context;
    public VoucherDAO(MargudsContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Voucher>> GetAllVouchersAsync()
    {
        return await _context.Vouchers
       .Include(v => v.VoucherDetail)
       .ToListAsync();

    }
    public async Task<Voucher> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentNullException($"id {id} not found");
        }
        var entity = await _context.Set<Voucher>()
           .SingleOrDefaultAsync(v => v.VoucherID == id);
        if (entity == null)
        {
            throw new ArgumentNullException($"Entity with id {id} not found");
        }
        return entity;
    }

    public async Task<Voucher> GetVoucherByCode(string voucherCode)
    {
        if (string.IsNullOrEmpty(voucherCode))
        {
            throw new ArgumentException("Voucher Code is required.", nameof(voucherCode));
        }
        var voucher = await _context.Vouchers
        .Include(v => v.VoucherDetail)
        .FirstOrDefaultAsync(v => v.VoucherCode == voucherCode);
       

        if (voucher == null)
        {
            throw new Exception("Voucher not found");
        }

        return voucher;
    }

    public async Task<Voucher> GetVoucherByAccountID(string accountID)
    {
        if (string.IsNullOrEmpty(accountID))
        {
            throw new ArgumentException("Account ID is required.", nameof(accountID));
        }
        var voucher = await _context.Vouchers
        .Include(v => v.VoucherDetail)
        .FirstOrDefaultAsync(v => v.AccountID == accountID);


        if (voucher == null)
        {
            throw new Exception("Voucher not found");
        }

        return voucher;
    }


    //////////////////////////////////////////
    private static Random random = new Random();

    public string GenerateVoucherCode(int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder voucherCode = new StringBuilder("MG");

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(chars.Length);
            voucherCode.Append(chars[index]);
        }

        return voucherCode.ToString();
    }
    /////////////////////////////////////////
}

