using Domain;
using Entity;
using Model;
using System.Collections.Generic;

namespace Mapper
{
    public static class DeveloperMapper
    {
        public static IEnumerable<DeveloperDTO> ToDTO(this IEnumerable<DeveloperModel> developers)
        {
            List<DeveloperDTO> result = new();
            foreach (var t in developers)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<DeveloperEntity> ToEntity(this IEnumerable<DeveloperDTO> developers)
        {
            List<DeveloperEntity> result = new();
            foreach (var t in developers)
                result.Add(t.ToEntity());
            return result;
        }
        public static IEnumerable<DeveloperDTO> ToDTO(this IEnumerable<DeveloperEntity> developers)
        {
            List<DeveloperDTO> result = new List<DeveloperDTO>();
            foreach (var t in developers)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<DeveloperModel> ToModel(this IEnumerable<DeveloperDTO> developers)
        {
            List<DeveloperModel> result = new();
            foreach (var t in developers)
                result.Add(t.ToModel());
            return result;
        }
        public static DeveloperEntity ToEntity(this DeveloperDTO developer)
        {
            developer ??= new DeveloperDTO();
            return new DeveloperEntity
            {
                Id = developer.Id,
                Name = developer.Name,
                PositionId = developer.PositionId,
                Position = developer.Position?.ToEntity()
            };
        }
        public static DeveloperDTO ToDTO(this DeveloperEntity developer)
        {
            developer ??= new DeveloperEntity();
            return new DeveloperDTO
            {
                Id = developer.Id,
                Name = developer.Name,
                PositionId = developer.PositionId,
                Position = developer.Position?.ToDTO()
            };
        }
        public static DeveloperDTO ToDTO(this DeveloperModel developer)
        {
            developer ??= new DeveloperModel();
            return new DeveloperDTO
            {
                Id = developer.Id,
                Name = developer.Name,
                PositionId = developer.PositionId,
                Position = developer.Position?.ToDTO()
            };
        }
        public static DeveloperModel ToModel(this DeveloperDTO developer)
        {
            developer ??= new DeveloperDTO();
            return new DeveloperModel
            {
                Id = developer.Id,
                Name = developer.Name,
                PositionId = developer.PositionId,
                Position = developer.Position?.ToModel()
            };
        }
    }
}
