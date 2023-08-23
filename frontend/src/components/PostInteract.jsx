import { useState } from "react";
import UserProfile from "./UserProfile";
export default function PostInteract({ post, currentUser }) {
  const [editReply, setEditReply] = useState(false);
  const [showReply, setShowReply] = useState(false);
  const [comments, setComments] = useState(post.comments);
  const [reply, setReply] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();
    const comment = {
      UserId: currentUser.id,
      PosterName: currentUser.username,
      Content: reply,
      PostId: post.id,
    };
    const response = await axios.post("/api/AddComment", comment);
    const responseCommments = await axios.get("/api/Comments/" + post.id);
    setComments(responseCommments.data);
    setEditReply(!editReply);
    setReply("");
  };
  return (
    <div>
      {editReply == false ? (
        <>
          <button
            onClick={() => {
              setEditReply(!editReply);
              setShowReply(true);
            }}
          >
            Reply
          </button>
          <button
            onClick={() => {
              setShowReply(!showReply);
            }}
          >
            {comments.length == 0
              ? "no comments"
              : "show " + comments.length + " comments"}
          </button>
        </>
      ) : (
        <form>
          <input
            className="search-bar"
            value={reply}
            onChange={(e) => setReply(e.target.value)}
            type="text"
          />
          <button onClick={handleSubmit}>Add</button>
          <button
            onClick={() => {
              setEditReply(!editReply);
            }}
          >
            X
          </button>
        </form>
      )}
      {showReply == false
        ? ""
        : comments.map((item) => (
            <div key={item.id} className="comments">
              <UserProfile username={item.posterName}></UserProfile>{" "}
              {item.content}
            </div>
          ))}
    </div>
  );
}
