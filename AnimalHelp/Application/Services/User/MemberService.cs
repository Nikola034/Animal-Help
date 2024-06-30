using AnimalHelp.Domain.Model;
using AnimalHelp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace AnimalHelp.Application.UseCases.User
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void UpdateMember(Member member, string name, string surname, DateTime birthDate, Gender gender, string phoneNumber)
        {
            member.Update(name, surname, birthDate, gender, phoneNumber);  
            _memberRepository.Update(member.Id, member);
        }
    
        public void DeleteAccount(Member member)
        {
            _memberRepository.Delete(member.Id);
        }

        public Member? GetMemberById(string memberId)
        {
            return _memberRepository.Get(memberId);
        }

        public List<Member> GetAllMembers() => _memberRepository.GetAll();

        public Member AddMember(Member member)
        {
            return _memberRepository.Add(member);
        }


    }

}
