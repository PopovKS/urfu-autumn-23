namespace WebApplication2.Api2.Model;

public record ProductListDto(IReadOnlyList<ProductListItemDto> Items);
public record ProductListItemDto(string Name, long Cost);