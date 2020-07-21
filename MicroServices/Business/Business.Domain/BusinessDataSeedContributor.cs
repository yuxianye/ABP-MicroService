using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Linq;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Business.BaseData;
using System.ComponentModel.Design;

namespace Business
{

    public class BusinessDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IAsyncQueryableExecuter _queryableExecuter;

        private readonly IRepository<BaseData.DataDictionary, Guid> _dataDictionaryRepository;
        private readonly IRepository<BaseData.DataDictionaryDetail, Guid> _dataDictionaryDetailRepository;

        private readonly IRepository<Organization> _organizationRepository;

        //private readonly ISelectionService _selectionService;

        public BusinessDataSeedContributor(
            IGuidGenerator guidGenerator,
            IAsyncQueryableExecuter queryableExecuter,

            IRepository<BaseData.DataDictionary, Guid> dataDictionaryRepository,
            IRepository<BaseData.DataDictionaryDetail, Guid> dataDictionaryDetailRepository,
            IRepository<Organization> organizationRepository
            )
        {
            _guidGenerator = guidGenerator;
            _queryableExecuter = queryableExecuter;

            _dataDictionaryRepository = dataDictionaryRepository;
            _dataDictionaryDetailRepository = dataDictionaryDetailRepository;


            _organizationRepository = organizationRepository;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateDataDictionarySeedData();

            await CreateOrganizationSeedData();

            await CreateJobSeedData();

        }



        #region 数据字典

        private async Task CreateDataDictionarySeedData()
        {

            //客户等级字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "客户等级"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "客户等级", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "一级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "一级", "一级", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "二级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "二级", "二级", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "三级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "三级", "三级", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "四级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "四级", "四级", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "五级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "五级", "五级", 5));
                }
            }

            //设备类别字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备类别"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备类别", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "机床"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "机床", "机床", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "机器人"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "机器人", "机器人", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "机械手"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "机械手", "机械手", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "注塑机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "注塑机", "注塑机", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "冲压机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "冲压机", "冲压机", 5));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "压力机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "压力机", "压力机", 6));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "打磨机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "打磨机", "打磨机", 7));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "切割机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "切割机", "切割机", 8));
                }
            }

            //设备品牌字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备品牌"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备品牌", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "西门子"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "西门子", "西门子", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "华中数控"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "华中数控", "华中数控", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "库卡"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "库卡", "库卡", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "ABB"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "ABB", "ABB", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "安川"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "安川", "安川", 5));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "新松"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "新松", "新松", 6));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "三一"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "三一", "三一", 7));
                }
            }

            //设备状态字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备状态"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备状态", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "在用"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "在用", "在用", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "维修"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "维修", "维修", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "报废"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "报废", "报废", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "外借"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "外借", "外借", 4));
                }

            }

            //设备检查状态字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备检查状态"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备检查状态", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "正常"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "正常", "正常", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "异常"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "异常", "异常", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "异常不影响生产"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "异常不影响生产", "异常不影响生产", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "待检查"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "待检查", "待检查", 4));
                }
            }

            //设备维修结果字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备维修结果"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备维修结果", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "待维修"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "待维修", "待维修", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "维修完成待观察"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "维修完成待观察", "维修完成待观察", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "维修完成"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "维修完成", "维修完成", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "已正常"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "已正常", "已正常", 4));
                }
            }

            //设备备件类别字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "设备备件类别"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "设备备件类别", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "模具"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "模具", "模具", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "磨具"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "磨具", "磨具", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "轴承"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "轴承", "轴承", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "螺杆"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "螺杆", "螺杆", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "螺帽"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "螺帽", "螺帽", 5));
                }
            }

            //计量单位字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "计量单位"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "计量单位", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "吨"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "吨", "吨", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "箱"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "箱", "箱", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "米"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "米", "米", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "千克"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "千克", "千克", 4));
                }
            }

            //产品类别字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "产品类别"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "产品类别", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "柴油发动机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "柴油发动机", "柴油发动机", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "汽油发动机"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "汽油发动机", "汽油发动机", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "耐火砖"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "耐火砖", "耐火砖", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "砂轮"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "砂轮", "砂轮", 4));
                }
            }

            //订单状态字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "订单状态"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "订单状态", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "新建"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "新建", "新建", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "已排产"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "已排产", "已排产", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "生产中"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "生产中", "生产中", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "生产完"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "生产完", "生产完", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "待发货"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "待发货", "待发货", 5));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "已发货"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "已发货", "已发货", 6));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "完结"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "完结", "完结", 7));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "撤销"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "撤销", "撤销", 8));
                }

            }

            //质量检查结果字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "质量检查结果"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "质量检查结果", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "合格"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "合格", "合格", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "不合格"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "不合格", "不合格", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "降级使用"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "降级使用", "降级使用", 3));
                }
            }

            //供应商等级字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "供应商等级"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "供应商等级", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "一级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "一级", "一级", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "二级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "二级", "二级", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "三级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "三级", "三级", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "四级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "四级", "四级", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "五级"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "五级", "五级", 5));
                }
            }


            //围岩级别字典
            if (!await _dataDictionaryRepository.AnyAsync(a => a.Name == "围岩级别"))
            {
                var dataDictionary = await _dataDictionaryRepository.InsertAsync(new BaseData.DataDictionary(_guidGenerator.Create(), "围岩级别", null));

                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅰ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅰ", "Ⅰ", 1));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅱ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅱ", "Ⅱ", 2));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅲ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅲ", "Ⅲ", 3));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅳ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅳ", "Ⅳ", 4));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅴ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅴ", "Ⅴ", 5));
                }
                if (!await _dataDictionaryDetailRepository.AnyAsync(a => a.Label == "Ⅵ"))
                {
                    await _dataDictionaryDetailRepository.InsertAsync(new BaseData.DataDictionaryDetail(_guidGenerator.Create(), dataDictionary.Id, "Ⅵ", "Ⅵ", 6));
                }
            }




            //for (int i = 1; i < 200; i++)
            //{
            //    if (await _enterpriseRepository.AnyAsync(a => a.Name == $"新密第{i}耐火厂"))
            //        await _enterpriseRepository.InsertAsync(
            //            new Enterprises.Enterprise(_guidGenerator.Create(), $"新密第{i}耐火厂", $"新密市嵩山大道{i}号", "13800138000", $"测试数据{i}"));
            //}




        }

        #endregion

        #region 组织结构管理

        private async Task CreateOrganizationSeedData()
        {
            //组织结构
            if (!await _organizationRepository.AnyAsync(a => a.FullName == "安世亚太"))
            {
                var organization = await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 1, null, "安世亚太", "安世亚太", 1, false, true) { CascadeId = ".0.1." });
                Organization organizationBeijing = null;
                if (!await _organizationRepository.AnyAsync(a => a.Name == "北京子公司"))
                {
                    organizationBeijing = await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 1, organization.Id, "北京子公司", "安世亚太/北京子公司", 1, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "上海子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "上海子公司", "安世亚太/上海子公司", 2, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "上海SOE公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "上海SOE公司", "安世亚太/上海SOE公司", 3, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "广州子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "广州子公司", "安世亚太/广州子公司", 5, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "南京子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "南京子公司", "安世亚太/南京子公司", 6, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "武汉分公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "武汉分公司", "安世亚太/武汉分公司", 7, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "成都子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "成都子公司", "安世亚太/成都子公司", 8, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "重庆分公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "重庆分公司", "安世亚太/重庆分公司", 9, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "西安分公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "西安分公司", "安世亚太/西安分公司", 10, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "沈阳子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "沈阳子公司", "安世亚太/沈阳子公司", 11, false, true) { CascadeId = ".0.1.1." });
                }
                if (!await _organizationRepository.AnyAsync(a => a.Name == "香港子公司"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 2, organization.Id, "香港子公司", "安世亚太/香港子公司", 12, false, true) { CascadeId = ".0.1.1." });
                }


                if (!await _organizationRepository.AnyAsync(a => a.Name == "机车行业部"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 3, organizationBeijing?.Id, "机车行业部", "安世亚太/北京子公司/机车行业部", 1, false, true) { CascadeId = ".0.1.1.1." });
                }

                if (!await _organizationRepository.AnyAsync(a => a.Name == "市场部"))
                {
                    await _organizationRepository.InsertAsync(new Organization(_guidGenerator.Create(), 3, organizationBeijing?.Id, "市场部", "安世亚太/北京子公司/市场部", 2, false, true) { CascadeId = ".0.1.1.1." });
                }


            }
        }

        #endregion

        #region 岗位管理

        private async Task CreateJobSeedData()
        {


        }

        #endregion



        //for (int i = 1; i < 200; i++)
        //{
        //    if (await _enterpriseRepository.AnyAsync(a => a.Name == $"新密第{i}耐火厂"))
        //        await _enterpriseRepository.InsertAsync(
        //            new Enterprises.Enterprise(_guidGenerator.Create(), $"新密第{i}耐火厂", $"新密市嵩山大道{i}号", "13800138000", $"测试数据{i}"));
        //}




    }




}


