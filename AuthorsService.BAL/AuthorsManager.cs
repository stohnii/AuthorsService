using AuthorsService.BAL.DTOs;
using AuthorsService.DAL;
using AuthorsService.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsService.BAL
{
    public class AuthorsManager : IAuthorsManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorDto> AddOrUpdateAsync(AuthorDto author)
        {
            try
            {
                if (author.Id == 0)
                {
                    author.RegistrationDate = DateTime.UtcNow;
                    var result = await _unitOfWork.AuthorsRepository
                                .AddAsync(_mapper.Map<Author>(author));
                    await _unitOfWork.Commit();
                    return _mapper.Map<AuthorDto>(result.Entity);
                }
                else
                {
                    Author result = await _unitOfWork.AuthorsRepository
                                    .UpdateAsync(_mapper.Map<Author>(author));
                    await _unitOfWork.Commit();
                    return _mapper.Map<AuthorDto>(result);
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync(bool onlyActive = true)
        {
            IEnumerable<Author> result = await _unitOfWork.AuthorsRepository.GetAllAsync(onlyActive);
            return _mapper.Map<IEnumerable<AuthorDto>>(result);
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            Author result = await _unitOfWork.AuthorsRepository.GetByIdAsync(id);
            return _mapper.Map<AuthorDto>(result);
        }
    }
}
