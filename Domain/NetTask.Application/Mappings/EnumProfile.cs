using NetTask.Application.Dtos.Enum;
using NetTask.Application.Mappings.Actions;

namespace NetTask.Application.Mappings;
internal class EnumProfile: Profile
{
    public EnumProfile()
    {
        CreateMap<KeyValuePair<int, string>, ReadEnumDto>()
            .BeforeMap<KeyValuePair_To_ReadEnumDto_MappingAction>();
    }
}
