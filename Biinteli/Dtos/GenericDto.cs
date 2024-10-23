namespace App.Dtos;

abstract class GenericDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
