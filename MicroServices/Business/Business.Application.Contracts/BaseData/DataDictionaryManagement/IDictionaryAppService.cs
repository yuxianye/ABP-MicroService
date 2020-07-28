﻿using Business.BaseData.DataDictionaryManagement.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Business.BaseData.DataDictionaryManagement
{
    public interface IDictionaryAppService : IApplicationService
    {
        Task<PagedResultDto<DictionaryDto>> GetAll(GetDictionaryInputDto input);

        Task<DictionaryDto> Get(Guid id);

        //Task<DictionaryDto> GetByName(GetDicDto getDicDto);

        Task<DictionaryDto> Get(string name);


        Task<DictionaryDto> Create(CreateOrUpdateDictionaryDto input);

        Task<DictionaryDto> Update(Guid id, CreateOrUpdateDictionaryDto input);

        Task Delete(List<Guid> ids);
    }
}
