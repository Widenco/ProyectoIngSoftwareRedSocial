using AppRedSocial.Models;
using AppRedSocial.Repositories;

namespace AppRedSocial.Services
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(
            ICommentRepository commentRepository,
            IPostRepository postRepository,
            IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<Comment> AddCommentAsync(int postId, string userName, string content)
        {
            var user = await _userRepository.GetUserByUserName(userName)
            ?? throw new Exception("El usuario no existe.");

            var post = await _postRepository.GetPostByIdAsync(postId)
                ?? throw new Exception("El post no existe.");

            if (string.IsNullOrWhiteSpace(content))
                throw new Exception("El comentario no puede estar vacío.");

            var comment = new Comment
            {
                UserId = user.Id,
                PostId = postId,
                Content = content,
            };

            await _commentRepository.AddCommentAsycn(comment);

            return comment;
        }

        public async Task<bool> DeleteCommentAsync(int commentId, string userName)
        {
            var comment = await _commentRepository.GetCommentById(commentId)
            ?? throw new Exception("Comentario no encontrado.");

            if (comment.User.UserName != userName)
            {
                var user = await _userRepository.GetUserByUserName(userName);
                if (user == null || user.Role.Name != "Admin")
                    throw new Exception("No tienes permiso para eliminar este comentario.");
            }

            await _commentRepository.DeleteCommentAsycn(comment);
            return true;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId)
        {
            return await _commentRepository.GetCommentByPostAsycn(postId);
        }
    }
}
