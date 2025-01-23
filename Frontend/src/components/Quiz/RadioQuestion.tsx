import React from "react";
import { FormControlLabel, Radio, RadioGroup, FormLabel, Box } from "@mui/material";

interface RadioQuestionProps {
  questionId: number;
  question: string;
  options: string[];
  handleChange: (questionId: number, value: string) => void;
}

const RadioQuestion: React.FC<RadioQuestionProps> = ({
  questionId,
  question,
  options,
  handleChange,
}) => {
  return (
    <div>
      <Box key={questionId} sx={{ marginBottom: "20px" }}>
        <FormLabel
          sx={{
            fontSize: "1.1rem",
            fontWeight: 500,
            marginBottom: "10px",
            display: "block",
          }}
        >
          {question}
        </FormLabel>
        <RadioGroup
          onChange={(e) => handleChange(questionId, e.target.value)}
          sx={{ display: "flex", flexDirection: "column" }}
        >
          {options.map((option) => (
            <FormControlLabel
              key={option}
              control={<Radio />}
              label={option}
              value={option}
              sx={{
                marginBottom: "10px",
                "& .MuiRadio-root": {
                  color: "#00796b",
                },
              }}
            />
          ))}
        </RadioGroup>
      </Box>
    </div>
  );
};

export default RadioQuestion;
