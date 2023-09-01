import { useEffect, useState } from "react";

export default function MenuButton({ todo, content }) {
  return (
    <div className="" onClick={() => todo(content)}>
      {content}
    </div>
  );
}
