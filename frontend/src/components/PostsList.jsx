import { useEffect, useState } from "react";
import Posts from "./Posts";

export default function PostsList() {
  const [postsList, setPostsList] = useState(null);

  useEffect(() => {
    const getPosts = async () => {
      try {
        const response = await axios.get("/api/Posts");
        console.log(response.data);
        setPostsList(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    getPosts();
  }, []);
  return (
    <div>
      {postsList == null
        ? ""
        : postsList.map((item) => (
            <Posts
              key={item.id}
              post={item.content}
              poster={item.posterName}
            ></Posts>
          ))}
    </div>
  );
}
