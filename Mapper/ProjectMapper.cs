using Domain;
using Entity;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Mapper
{
    public static class ProjectMapper
    {
        public static IEnumerable<ProjectDTO> ToDTO(this IEnumerable<ProjectModel> projects)
        {
            List<ProjectDTO> result = new();
            foreach (var t in projects)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<ProjectEntity> ToEntity(this IEnumerable<ProjectDTO> projects)
        {
            List<ProjectEntity> result = new();
            foreach (var t in projects)
                result.Add(t.ToEntity());
            return result;
        }
        public static IEnumerable<ProjectDTO> ToDTO(this IEnumerable<ProjectEntity> projects)
        {
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var t in projects)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<ProjectModel> ToModel(this IEnumerable<ProjectDTO> projects)
        {
            List<ProjectModel> result = new();
            foreach (var t in projects)
                result.Add(t.ToModel());
            return result;
        }
        public static ProjectEntity ToEntity(this ProjectDTO project)
        {
            project ??= new ProjectDTO();
            return new ProjectEntity
            {
                Id = project.Id,
                Client = project.Client?.ToEntity(),
                ClientId = project.ClientId,
                Developers = project.Developers?.ToEntity().ToList(),
                Name = project.Name
            };
        }
        public static ProjectDTO ToDTO(this ProjectEntity project)
        {
            project ??= new ProjectEntity();
            return new ProjectDTO
            {
                Id = project.Id,
                Client = project.Client?.ToDTO(),
                ClientId = project.ClientId,
                Developers = project.Developers?.ToDTO().ToList(),
                Name = project.Name
            };
        }
        public static ProjectDTO ToDTO(this ProjectModel project)
        {
            project ??= new ProjectModel();
            return new ProjectDTO
            {
                Id = project.Id,
                Client = project.Client?.ToDTO(),
                ClientId = project.ClientId,
                Developers = project.Developers?.ToDTO().ToList(),
                Name = project.Name
            };
        }
        public static ProjectModel ToModel(this ProjectDTO project)
        {
            project ??= new ProjectDTO();
            return new ProjectModel
            {
                Id = project.Id,
                Client = project.Client?.ToModel(),
                ClientId = project.ClientId,
                Developers = project.Developers?.ToModel().ToList(),
                Name = project.Name
            };
        }

    }
}
