import UserProfile from "./UserProfile";

export default function Posts({ post }) {
  return (
    <div>
      <UserProfile username={post.posterName}></UserProfile>
      <div>{post.content}</div>
    </div>
  );
}
