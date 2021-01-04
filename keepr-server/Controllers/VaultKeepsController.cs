using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        private readonly VaultsService _vs;
        public VaultKeepsController(VaultKeepsService vks, VaultsService vs)
        {
            _vks = vks;
            _vs = vs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> Post([FromBody] VaultKeep newVk)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                int vaultId = newVk.VaultId;
                Vault selectedVault = _vs.GetVaultById(vaultId, userInfo.Id);
                newVk.CreatorId = userInfo.Id;
                return Ok(_vks.Create(newVk, userInfo.Id, selectedVault));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vks.Delete(id, userInfo.Id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }
    }
}