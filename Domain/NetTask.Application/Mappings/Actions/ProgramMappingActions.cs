using NetTask.Application.Dtos.Program;

namespace NetTask.Application.Mappings.Actions;

internal class CreateAdditionalProgramInformationDto_To_AdditionalProgramInformation_MappingAction
    : IMappingAction<CreateAdditionalProgramInformationDto, AdditionalProgramInformation>
{
    public void Process(CreateAdditionalProgramInformationDto source, AdditionalProgramInformation destination, ResolutionContext context)
    {
        destination.Type = source.TypeId;
        destination.MinQualification = source.MinQualificationId;
    }
}

internal class UpdateAdditionalProgramInformationDto_To_AdditionalProgramInformation_MappingAction
    : IMappingAction<UpdateAdditionalProgramInformationDto, AdditionalProgramInformation>
{
    public void Process(UpdateAdditionalProgramInformationDto source, AdditionalProgramInformation destination, ResolutionContext context)
    {
        destination.Type = source.TypeId;
        destination.MinQualification = source.MinQualificationId;
    }
}

internal class AdditionalProgramInformation_To_ReadAdditionalProgramInformationDtoMappingAction
    : IMappingAction<AdditionalProgramInformation, ReadAdditionalProgramInformationDto>
{
    public void Process(AdditionalProgramInformation source, ReadAdditionalProgramInformationDto destination, ResolutionContext context)
    {
        destination.MinQualificationId = source.MinQualification;
        destination.TypeId = source.Type;
    }
}
