using Microsoft.AspNetCore.Mvc;
using SecretMessging.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretMessging.Controllers
{
    public class MsgController : Controller
    {
        sqlite db;
        public MsgController(sqlite _db)
        {
            db = _db;
        }

        public IActionResult Reads_view(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) RedirectToAction("send_view");
            var item = db.message.Where(m => m.Url == url).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("errorspage", "Msg");
            }
            db.message.Remove(item);
            db.SaveChanges();
          
            ViewData.Model = item;
            return View();
        }
        public Object send_action(string Content, bool Crypted)
        {
            //to make a unique url by taking the last id for table wich is unique and convert it to string then convert that string into asci table which will gave us a number again but the number will be longer than the id number and the convert this number to string and get the asci character from it and repeat this process three times then convert the fainal number we got into letter so it will be a unique id from letter 
            var lastIdtemp = db.message.OrderBy(M => M.id).LastOrDefault()?.id;
            string lastid = "0";
            if (lastIdtemp.HasValue)
            {
                lastid = lastIdtemp.Value.ToString();
            }
            for (int i = 0; i < 2; i++)
            {
                string temp = "";
                for (int index = 0; index < lastid.Count(); index++)
                {
                    temp += ((int)lastid[index]).ToString();
                };
                lastid = temp;
            }
            var list = new List<char> { 't', 'e', 'x', 'l', 'j', 'k', 'n', 'u', 'r', 'b' };
            string url = "";
            for (int index = 0; index < lastid.Count(); index++)
            {
                url += list[int.Parse(lastid[index].ToString())];
            }
            db.message.Add(new Models.message() { content = Content, Url = url ,IsEncrypted =Crypted });
            db.SaveChanges();
            return url;
        }
        public Object errorspage()
        {
            return View();
        }
        public Object send_view()
        {
            return View();
        }
    }
}
