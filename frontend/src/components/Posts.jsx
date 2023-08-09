import UserProfile from "./UserProfile";

export default function Posts({ post, poster }) {
  return (
    <div className="post-containder">
      <UserProfile username={poster}></UserProfile>
      <div>{post}</div>
    </div>
  );
}
