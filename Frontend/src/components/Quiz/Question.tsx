import React from "react";

interface QuestionProps {
  question: string;
  children: React.ReactNode;
}

const Question: React.FC<QuestionProps> = ({ question, children }) => {
  return (
    <div>
      <div
        style={{
          fontSize: "1.1rem",
          fontWeight: 500,
          marginBottom: "10px",
          display: "block",
        }}
      >
        {question}
      </div>
      {children}
    </div>
  );
};

export default Question;
