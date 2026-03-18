using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Abp.AspNetCore.Mvc.Controllers;
using Nhom10_HoDuongTien.Application.Services.DeThi;
using Abp.Domain.Repositories;
using Nhom10_HoDuongTien.Core.Entities.Toeic;

namespace Nhom10_HoDuongTien.Web.Mvc.Controllers
{
    [Route("DeThi")]
    public class DeThiController : AbpController
    {
        private readonly WordParser _parser;
        private readonly IRepository<DeThi, int> _deThiRepo;
        private readonly IRepository<PhanThi, int> _phanThiRepo;
        private readonly IRepository<CauHoi, int> _cauHoiRepo;
        private readonly IRepository<LuaChon, int> _luaChonRepo;

        
        public DeThiController(
            WordParser parser,
            IRepository<DeThi, int> deThiRepo,
            IRepository<PhanThi, int> phanThiRepo,
            IRepository<CauHoi, int> cauHoiRepo,
            IRepository<LuaChon, int> luaChonRepo)
        {
            _parser = parser;
            _deThiRepo = deThiRepo;
            _phanThiRepo = phanThiRepo;
            _cauHoiRepo = cauHoiRepo;
            _luaChonRepo = luaChonRepo;
        }

      
        [HttpGet("Upload")]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("UploadWord")]
        public async Task<IActionResult> UploadWord(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Chưa chọn file!";
                return View("Upload");
            }

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

           
            var questions = _parser.Parse(filePath);

           
            var deThi = await _deThiRepo.InsertAsync(new DeThi
            {
                TieuDe = file.FileName,
                ThoiGianThi = 60
            });

            await CurrentUnitOfWork.SaveChangesAsync();

           
            var phanThi = await _phanThiRepo.InsertAsync(new PhanThi
            {
                DeThiId = deThi.Id,
                SoPhan = 1
            });

            await CurrentUnitOfWork.SaveChangesAsync();

            int soCau = 1;

            
            foreach (var q in questions)
            {
                var cauHoi = await _cauHoiRepo.InsertAsync(new CauHoi
                {
                    PhanThiId = phanThi.Id,
                    SoCauHoi = soCau++,
                    NoiDungCauHoi = q.Content
                });

                await CurrentUnitOfWork.SaveChangesAsync();

                foreach (var a in q.Answers)
                {
                    await _luaChonRepo.InsertAsync(new LuaChon
                    {
                        CauHoiId = cauHoi.Id,
                        Nhan = a.Key,
                        NoiDung = a.Content,
                        LaDapAnDung = a.Key == q.CorrectAnswer
                    });
                }
            }

            ViewBag.Message = $"✔ Tạo đề thi thành công ({questions.Count} câu)";

            return View("Upload");
        }

       
        [HttpGet("Thi/{id}")]
        public IActionResult Thi(int id)
        {
            var phanThi = _phanThiRepo.GetAllIncluding(p => p.CauHois)
                .FirstOrDefault(p => p.DeThiId == id);

            if (phanThi == null)
            {
                return Content("Không tìm thấy đề thi!");
            }

            var cauHois = _cauHoiRepo.GetAllIncluding(c => c.LuaChons)
                .Where(c => c.PhanThiId == phanThi.Id)
                .ToList();

            ViewBag.CauHois = cauHois;

            return View();
        }

        [HttpPost("NopBai")]
        public IActionResult NopBai()
        {
            int score = 0;

            foreach (var key in Request.Form.Keys)
            {
                var luaChonId = int.Parse(Request.Form[key]);

                var lc = _luaChonRepo.FirstOrDefault(luaChonId);

                if (lc != null && lc.LaDapAnDung)
                {
                    score++;
                }
            }

            ViewBag.Score = score;

            return View("KetQua");
        }
    }
}