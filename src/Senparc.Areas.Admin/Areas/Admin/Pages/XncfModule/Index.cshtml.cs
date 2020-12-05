using Microsoft.AspNetCore.Mvc;
using Senparc.Ncf.Core.Models;
using Senparc.Ncf.Core.Models.DataBaseModel;
using Senparc.Ncf.Service;
using Senparc.Ncf.XncfBase;
using Senparc.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Senparc.Areas.Admin.Areas.Admin.Pages
{
    public class XncfModuleIndexModel : BaseAdminPageModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly XncfModuleServiceExtension _xncfModuleServiceEx;
        private readonly SysMenuService _sysMenuService;
        private readonly Lazy<SystemConfigService> _systemConfigService;

        public XncfModuleIndexModel(IServiceProvider serviceProvider, XncfModuleServiceExtension xncfModuleServiceEx,
            SysMenuService sysMenuService, Lazy<SystemConfigService> systemConfigService)
        {
            CurrentMenu = "XncfModule";

            this._serviceProvider = serviceProvider;
            this._xncfModuleServiceEx = xncfModuleServiceEx;
            this._sysMenuService = sysMenuService;
            this._systemConfigService = systemConfigService;
        }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// ���ݿ��Ѵ��XncfModules
        /// </summary>
        public PagedList<XncfModule> XncfModules { get; set; }
        public List<IXncfRegister> NewXncfRegisters { get; set; }

        private void LoadNewXncfRegisters(PagedList<XncfModule> xncfModules)
        {
            NewXncfRegisters = XncfRegisterManager.RegisterList.Where(z => !z.IgnoreInstall && !xncfModules.Exists(m => m.Uid == z.Uid && m.Version == z.Version)).ToList() ?? new List<IXncfRegister>();
        }

        public async Task OnGetAsync()
        {
            //���²˵�����
            await _sysMenuService.GetMenuDtoByCacheAsync(true).ConfigureAwait(false);
            XncfModules = await _xncfModuleServiceEx.GetObjectListAsync(PageIndex, 10, _ => true, _ => _.AddTime, Ncf.Core.Enums.OrderingType.Descending);
            LoadNewXncfRegisters(XncfModules);
        }

        /// <summary>
        /// ɨ����ģ��
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetScanAsync(string uid)
        {
            var result = await _xncfModuleServiceEx.InstallModuleAsync(uid);
            XncfModules = result.Item1;
            base.SetMessager(Ncf.Core.Enums.MessageType.info, result.Item2, true);

            //if (backpage=="Start")
            return RedirectToPage("Start", new { uid = uid });//ʼ�յ�����ҳ
            //return RedirectToPage("Index");
        }

        /// <summary>
        /// ���ء�ģ���������
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostHideManagerAsync()
        {
            //TODO:ʹ��DTO����
            var systemConfig = _systemConfigService.Value.GetObject(z => true);
            systemConfig.HideModuleManager = systemConfig.HideModuleManager.HasValue && systemConfig.HideModuleManager.Value == true ? false : true;
            await _systemConfigService.Value.SaveObjectAsync(systemConfig);
            if (systemConfig.HideModuleManager == true)
            {
                return RedirectToPage("../Index");
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        /// <summary>
        /// ���ء�ģ��������� handler=HideManagerAjax
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostHideManagerAjaxAsync()
        {
            //TODO:ʹ��DTO����
            var systemConfig = _systemConfigService.Value.GetObject(z => true);
            systemConfig.HideModuleManager = systemConfig.HideModuleManager.HasValue && systemConfig.HideModuleManager.Value == true ? false : true;
            await _systemConfigService.Value.SaveObjectAsync(systemConfig);
            //if (systemConfig.HideModuleManager == true)
            //{
            //    return RedirectToPage("../Index");
            //}
            //else
            //{
            //    return RedirectToPage("./Index");
            //}
            return Ok(new { systemConfig.HideModuleManager });
        }

        /// <summary>
        /// ��ȡ�Ѱ�װģ��ģ�� handler=Mofules
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetMofulesAsync(int pageIndex = 0, int pageSize = 0)
        {
            //���²˵�����
            await _sysMenuService.GetMenuDtoByCacheAsync(true).ConfigureAwait(false);
            PagedList<XncfModule> xncfModules = await _xncfModuleServiceEx.GetObjectListAsync(pageIndex, pageSize, _ => true, _ => _.AddTime, Ncf.Core.Enums.OrderingType.Descending);
            //xncfModules.FirstOrDefault().
            var xncfRegisterList = XncfRegisterList.Select(_ => new { _.Uid, homeUrl = _.GetAreaHomeUrl(), _.Icon });
            var result = from xncfModule in xncfModules
                         join xncfRegister in xncfRegisterList on xncfModule.Uid equals xncfRegister.Uid
                         into xncfRegister_left
                         from xncfRegister in xncfRegister_left.DefaultIfEmpty()
                         select new
                         {
                             xncfModule,
                             xncfRegister
                         };
            return Ok(new { result, FullSystemConfig.HideModuleManager });
        }

        /// <summary>
        /// ��ȡδ��װģ��ģ�� handler=UnMofules
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetUnMofulesAsync()
        {
            //�����Ѱ�װ��ģ��
            var oldXncfModules = await _xncfModuleServiceEx.GetObjectListAsync(0, 0, z => true, z => z.AddTime, Ncf.Core.Enums.OrderingType.Descending);
            //δ��װ��汾�Ѹ��£���ͬ����ģ��
            var newXncfRegisters = _xncfModuleServiceEx.GetUnInstallXncfModule(oldXncfModules);

            return Ok(newXncfRegisters.Select(z => new
            {
                z.MenuName,
                z.Name,
                z.Uid,
                Version = _xncfModuleServiceEx.GetVersionDisplayName(oldXncfModules, z),
                z.Icon
            })); ;
        }

        /// <summary>
        /// ɨ����ģ�� handler=ScanAjax
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetScanAjaxAsync(string uid)
        {
            var result = await _xncfModuleServiceEx.InstallModuleAsync(uid);
            //XncfModules = result.Item1;
            //base.SetMessager(Ncf.Core.Enums.MessageType.info, result.Item2, true);
            return Ok(result.XncfModuleList);
            //return RedirectToPage("Index");
        }

        /// <summary>
        /// �������ư�װģ��
        /// </summary>
        /// <param name="xncfName"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetInstallModuleAsync(string xncfName)
        {
            bool success = true;
            string message = null;
            if (base.FullSystemConfig.HideModuleManager == true)
            {
                success = false;
                message = "�Ѿ����á�����ģʽ�����޷����д˲���";
            }
            else
            {
                var docRegister = XncfRegisterManager.RegisterList.FirstOrDefault(z => z.Name == xncfName);
                if (docRegister == null)
                {
                    success = false;
                    message = "�ĵ�ģ�鲻���ڣ��޷���ɰ�װ��";
                }
                else
                {
                    try
                    {
                        //���Ҳ���װģ��
                        var docModule = await _xncfModuleServiceEx.GetObjectAsync(z => z.Uid == docRegister.Uid);
                        if (docModule == null)
                        {
                            await _xncfModuleServiceEx.InstallModuleAsync(docRegister.Uid);
                            docModule = await _xncfModuleServiceEx.GetObjectAsync(z => z.Uid == docRegister.Uid);
                        }
                        //����ģ��
                        if (docModule.State != Ncf.Core.Enums.XncfModules_State.����)
                        {
                            docModule.UpdateState(Ncf.Core.Enums.XncfModules_State.����);
                            await _xncfModuleServiceEx.SaveObjectAsync(docModule);
                        }

                        message = "��װ�ɹ���";
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        message = "��װʧ�ܣ�" + ex.Message;
                    }
                }
            }

            return new JsonResult(new { success, message });

        }
    }
}