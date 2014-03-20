using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using DBTest.Models;
using DBTest.DataAccessLayer;

namespace DBTest.Controllers
{
    public class HostServerController : Controller
    {
        private readonly ServerContext _serverContext = new ServerContext();

        // GET: /HostServer/
        public async Task<ActionResult> Index()
        {
            return View(await _serverContext.HostServers.ToListAsync());
        }

        // GET: /HostServer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostServer hostserver = await _serverContext.HostServers.FindAsync(id);
            if (hostserver == null)
            {
                return HttpNotFound();
            }
            return View(hostserver);
        }

        // GET: /HostServer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HostServer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="HostServerId,Name,ServerStatus,Specs")] HostServer hostserver)
        {
            if (ModelState.IsValid)
            {
                _serverContext.HostServers.Add(hostserver);
                await _serverContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hostserver);
        }

        // GET: /HostServer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostServer hostserver = await _serverContext.HostServers.FindAsync(id);
            if (hostserver == null)
            {
                return HttpNotFound();
            }
            return View(hostserver);
        }

        // POST: /HostServer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="HostServerId,Name,ServerStatus,Specs")] HostServer hostserver)
        {
            if (ModelState.IsValid)
            {
                _serverContext.Entry(hostserver).State = EntityState.Modified;
                await _serverContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hostserver);
        }

        // GET: /HostServer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostServer hostserver = await _serverContext.HostServers.FindAsync(id);
            if (hostserver == null)
            {
                return HttpNotFound();
            }
            return View(hostserver);
        }

        // POST: /HostServer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HostServer hostserver = await _serverContext.HostServers.FindAsync(id);
            _serverContext.HostServers.Remove(hostserver);
            await _serverContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serverContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
