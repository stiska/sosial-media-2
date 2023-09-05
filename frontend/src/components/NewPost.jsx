import { useEffect, useState } from "react";

export default function NewPost({ currentUser }) {
  const [content, setContent] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();
    const postResponse = {
      UserId: currentUser.id,
      Content: content,
    };
    const response = await axios.post("/api/Addpost", postResponse);
    setContent("");
    console.log(postResponse);

    console.log(response.data);
  };

  return (
    <div>
      <form action="">
        <textarea
          value={content}
          onChange={(e) => setContent(e.target.value)}
        />
        <button onClick={handleSubmit}>Publish</button>
      </form>
    </div>
  );
}
