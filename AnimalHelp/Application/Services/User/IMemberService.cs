using AnimalHelp.Domain.Model;
using System;
using System.Collections.Generic;

namespace AnimalHelp.Application.UseCases.User;

public interface IMemberService
{
    public void UpdateMember(Member member, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber);
    public void DeleteAccount(Member member);
    public Member? GetMemberById(string memberId);
    public Member AddMember(Member member);
    public List<Member> GetAllMembers();
}