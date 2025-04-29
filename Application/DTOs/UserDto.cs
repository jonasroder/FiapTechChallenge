namespace Application.DTOs;
public record UserDto(
    string Name, 
    string Email, 
    string Password
);