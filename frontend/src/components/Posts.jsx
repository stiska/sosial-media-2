import { useState } from "react";
import UserProfile from "./UserProfile";

export default function Posts({ post, currentUser }) {
  const [editReply, setEditReply] = useState(false);
  const [showReply, setShowReply] = useState(false);
  const [reply, setReply] = useState("");

  const handleSubmit = async () => {
    const comment = {
      UserId: currentUser.id,
      Content: reply,
      PostId: post.id,
    };
    const response = await axios.post("/api/AddComment", comment);
    console.log(response.data);
    setEditReply(!editReply);
  };
  return (
    <div className="post-containder">
      <UserProfile username={post.posterName}></UserProfile>
      <div>{post.content}</div>
      <div>
        {editReply == false ? (
          <>
            <button
              onClick={() => {
                setEditReply(!editReply);
              }}
            >
              Reply
            </button>
            <button
              onClick={() => {
                setShowReply(!showReply);
              }}
            >
              show comments
            </button>
          </>
        ) : (
          <>
            <input
              className="search-bar"
              value={reply}
              onChange={(e) => setReply(e.target.value)}
              type="text"
            />
            <button onClick={handleSubmit}>Add</button>
          </>
        )}
        {showReply == false
          ? ""
          : post.comments.map((item) => (
              <div key={item.id}>{item.content} </div>
            ))}
      </div>
    </div>
  );
}
