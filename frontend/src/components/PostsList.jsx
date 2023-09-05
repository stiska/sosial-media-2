import { useEffect, useState } from "react";
import PostInteract from "./PostInteract";
import Posts from "./Posts";

export default function PostsList({ currentUser }) {
  const [postsList, setPostsList] = useState(null);

  useEffect(() => {
    if (currentUser != null) {
      const getPosts = async () => {
        try {
          const response = await axios.get("/api/Posts/" + currentUser.id);
          console.log(response.data);
          setPostsList(response.data);
        } catch (error) {
          console.error("Error fetching data:", error);
        }
      };
      getPosts();
    } else {
      return;
    }
  }, [currentUser]);

  return (
    <div>
      {postsList == null
        ? ""
        : postsList.map((item) => (
            <div key={item.id} className="post-containder">
              <Posts post={item}></Posts>
              <PostInteract
                post={item}
                currentUser={currentUser}
              ></PostInteract>
            </div>
          ))}
    </div>
  );
}
