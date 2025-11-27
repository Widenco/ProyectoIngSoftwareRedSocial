using AppRedSocial.Models;
using AppRedSocial.Repositories;

namespace AppRedSocial.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        public async Task<Post> CreatePostAsync(string userName, string content)
        {
            var user = await _userRepository.GetUserByUserName(userName)
            ?? throw new Exception("El usuario no existe.");

            if (string.IsNullOrWhiteSpace(content))
                throw new Exception("El contenido del post no puede estar vacío.");

            var post = new Post
            {
                UserId = user.Id,
                Content = content
            };

            await _postRepository.AddAsync(post);

            return post;
        }

        public async Task<bool> DeletePostAsync(int postId, string userName)
        {
            var post = await _postRepository.GetByIdAsync(postId)
            ?? throw new Exception("Post no encontrado.");

            if (post.User.UserName != userName)
            {
                var user = await _userRepository.GetUserByUserName(userName);
                if (user == null || user.Role.Name != "Admin")
                    throw new Exception("No tienes permiso para eliminar este post.");
            }

            await _postRepository.DeleteAsync(post);
            return true;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetByIdAsync(postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserAsync(int userId)
        {
            return await _postRepository.GetByUserIdAsync(userId);
        }

        public async Task<bool> UpdatePostAsync(int postId, string userName, string newContent)
        {
            var post = await _postRepository.GetByIdAsync(postId)
            ?? throw new Exception("Post no encontrado.");

            if (post.User.UserName != userName)
            {
                var user = await _userRepository.GetUserByUserName(userName);
                if (user == null || user.Role.Name != "Admin")
                    throw new Exception("No tienes permiso para editar este post.");
            }

            if (string.IsNullOrWhiteSpace(newContent))
                throw new Exception("El contenido no puede estar vacío.");

            post.Content = newContent;

            await _postRepository.UpdateAsync(post);
            return true;
        }
    }
}
