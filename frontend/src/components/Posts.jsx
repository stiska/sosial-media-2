import { useEffect, useState } from "react";

export default function Posts() {
  const [posts, setPosts] = useState(null);

  useEffect(() => {
    const getPosts = async () => {
      try {
        const response = await axios.get("/api/Posts");
        console.log(response.data);
        setPosts(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getPosts();
  }, []);
  return (
    <div>
      {posts == null
        ? ""
        : posts.map((item) => (
            <div className="post-containder">{item.content}</div>
          ))}
    </div>
  );
}
