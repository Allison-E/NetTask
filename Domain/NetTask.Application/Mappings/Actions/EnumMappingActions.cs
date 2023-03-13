using NetTask.Application.Dtos.Enum;

namespace NetTask.Application.Mappings.Actions;
internal class KeyValuePair_To_ReadEnumDto_MappingAction: IMappingAction<KeyValuePair<int, string>, ReadEnumDto>
{
    public void Process(KeyValuePair<int, string> source, ReadEnumDto destination, ResolutionContext context)
    {
        destination.Id = source.Key;
        destination.Value = source.Value.SplitPascalCase();
    }
}
