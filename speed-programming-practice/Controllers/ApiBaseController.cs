using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity_AClass;

namespace FSESpeedProgrammingLib
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiBaseController<C, M> : ControllerBase where C: DbContext where M : BaseClass, new()
    {
        protected C context = null;
        public ApiBaseController(C context)
        {
            this.context = context;
        }

        [HttpGet]
        public virtual object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(context.Set<M>(), loadOptions);
        }

        [HttpGet]
        [Route("{PK}")]
        public virtual object Get(long? PK)
        {
            return context.Set<M>().Where(w => w.PK == PK);
        }

        [HttpPost]
        public virtual IActionResult Insert([FromForm] string values) //Core 2.1以降でApiControllerAttributeを使う時は[FromForm]が必須
        {
            var newObject = new M();
            JsonConvert.PopulateObject(values, newObject);

            if (!TryValidateModel(newObject))
                return BadRequest(GetFullErrorMessage());

            context.Set<M>().Add(newObject);
            try
            {
                context.SaveChanges();
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Insert Database Exception", error, null);
                return BadRequest(GetFullErrorMessage());
            }
            return Ok();
        }

        [HttpPut]
        public virtual IActionResult Update([FromForm] long key, [FromForm] string values)
        {
            var editObject = context.Set<M>().First(a => a.PK == key);
            JsonConvert.PopulateObject(values, editObject);

            if (!TryValidateModel(editObject))
                return BadRequest(GetFullErrorMessage());
            try
            {
                context.SaveChanges();
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Update Database Exception", error, null);
                return BadRequest(GetFullErrorMessage());
            }
            return Ok();
        }

        [HttpDelete]
        public virtual object Delete([FromForm] long key)
        {
            var delObject = context.Set<M>().First(a => a.PK == key);
            context.Set<M>().Remove(delObject);
            try
            {
                context.SaveChanges();
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Delete Database Exception", error, null);
                return BadRequest(GetFullErrorMessage());
            }
            return Ok();
        }

        protected string GetFullErrorMessage()
        {
            var messages = new List<string>();

            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }
            return String.Join(" ", messages);
        }
    }
}
