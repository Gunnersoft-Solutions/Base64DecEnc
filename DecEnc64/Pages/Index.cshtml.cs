using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Text;

namespace DecEnc64.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string? EncodeArea { get; set; }

        [BindProperty]
        public string? DecodeArea { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPostEncode()
        {
            if (EncodeArea != null)
            {
                var data = Encoding.UTF8.GetBytes(EncodeArea.Trim());
                DecodeArea = Convert.ToBase64String(data);
                ModelState.Clear();
                EncodeArea = "";
            }

        }

        public void OnPostDecode()
        {
            if (DecodeArea != null)
            {
                var b64 = Convert.FromBase64String(DecodeArea.Trim());
                EncodeArea = Encoding.UTF8.GetString(b64);
                ModelState.Clear();
                DecodeArea = "";
            }
        }
    }
}