using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PluginFramework.RequestModels;
using PluginFramework.UpdateModels;

namespace PluginFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EffectController : Controller
    {
        readonly ApplicationContext _context;
        public EffectController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task AddEffect(EffectRequest model)
        {
            var effect = new EffectModel
            {
                Name = model.Name
            };

            _context.Effects.Add(effect);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<EffectModel> GetEffect(int id)
        {
            var effect = _context.Effects
                 .Include(w => w.Id)
                 .FirstOrDefault(e => e.Id == id); 
            return effect;
        }

        [HttpGet]
        public async Task<List<EffectModel>> GetEffects()
        {
            var effect = _context.Effects.ToList();
            return effect;
        }

        [HttpDelete]
        public async Task DeleteEffect(int id)
        {
            var effect = _context.Effects.Where(s => s.Id == id).FirstOrDefault();
            if (effect != null)
            {
                _context.Effects.Remove(effect);
                _context.SaveChanges();
            }
        }

        [HttpPut]
        public async Task UpdateEffect(UpdateEffect model)
        {
            var effect = _context.Effects.FirstOrDefault();
            if (effect != null)
            {
                effect.Name = model.Name;
                _context.Effects.Update(effect);
                _context.SaveChanges();
            }
        }
    }
}
