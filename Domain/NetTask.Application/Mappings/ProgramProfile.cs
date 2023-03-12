using NetTask.Application.Dtos.Program;
using NetTask.Application.Mappings.Actions;

namespace NetTask.Application.Mappings;
public class ProgamProfile: Profile
{
    public ProgamProfile()
    {
        CreateMap<Program, ReadProgramDto>();
        CreateMap<CreateProgramDto, Program>();
        CreateMap<UpdateProgramDto, Program>();

        CreateMap<ProgramLocation, ReadProgramLocationDto>();
        CreateMap<CreateProgramLocationDto, ProgramLocation>();
        CreateMap<UpdateProgramLocationDto, ProgramLocation>();

        CreateMap<AdditionalProgramInformation, ReadAdditionalProgramInformationDto>()
            .BeforeMap<AdditionalProgramInformation_To_ReadAdditionalProgramInformationDtoMappingAction>();
        CreateMap<CreateAdditionalProgramInformationDto, AdditionalProgramInformation>()
            .BeforeMap<CreateAdditionalProgramInformationDto_To_AdditionalProgramInformation_MappingAction>();
        CreateMap<UpdateAdditionalProgramInformationDto, AdditionalProgramInformation>()
            .BeforeMap<UpdateAdditionalProgramInformationDto_To_AdditionalProgramInformation_MappingAction>();
    }
}