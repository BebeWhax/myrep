using Domain;
using Entity;
using Model;
using System.Collections.Generic;

namespace Mapper
{
    public static class PositionMapper
    {
        public static IEnumerable<PositionDTO> ToDTO(this IEnumerable<PositionModel> positions)
        {
            List<PositionDTO> result = new();
            foreach (var t in positions)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<PositionEntity> ToEntity(this IEnumerable<PositionDTO> positions)
        {
            List<PositionEntity> result = new();
            foreach (var t in positions)
                result.Add(t.ToEntity());
            return result;
        }
        public static IEnumerable<PositionDTO> ToDTO(this IEnumerable<PositionEntity> positions)
        {
            List<PositionDTO> result = new List<PositionDTO>();
            foreach (var t in positions)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<PositionModel> ToModel(this IEnumerable<PositionDTO> positions)
        {
            List<PositionModel> result = new();
            foreach (var t in positions)
                result.Add(t.ToModel());
            return result;
        }
        public static PositionEntity ToEntity(this PositionDTO position)
        {
            position ??= new PositionDTO();
            return new PositionEntity
            {
                Id = position.Id,
                Name = position.Name
            };
        }
        public static PositionDTO ToDTO(this PositionEntity position)
        {
            position ??= new PositionEntity();
            return new PositionDTO
            {
                Id = position.Id,
                Name = position.Name
            };
        }
        public static PositionDTO ToDTO(this PositionModel position)
        {
            position ??= new PositionModel();
            return new PositionDTO
            {
                Id = position.Id,
                Name = position.Name
            };
        }
        public static PositionModel ToModel(this PositionDTO position)
        {
            position ??= new PositionDTO();
            return new PositionModel
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}
