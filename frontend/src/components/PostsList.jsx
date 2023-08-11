import { useEffect, useState } from "react";
import PostInteract from "./PostInteract";
import Posts from "./Posts";

export default function PostsList({ currentUser }) {
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
            <div className="post-containder">
              <Posts key={item.id} post={item}></Posts>
              <PostInteract
                post={item}
                currentUser={currentUser}
              ></PostInteract>
            </div>
          ))}
    </div>
  );
}
