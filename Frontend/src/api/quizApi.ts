import api from "./api";
import {
  QuizQuestionResponseDTO,
  QuizResultResponseDTO,
  QuizSubmitResponseDTO,
} from "../types/types.ts";

export const getQuizQuestions = async (): Promise<QuizQuestionResponseDTO[]> => {
  const response = await api.get("/quizzes/questions");

  return response.data;
};

export const getHighScores = async (): Promise<QuizResultResponseDTO[]> => {
  const response = await api.get("/quizzes/highscores");

  return response.data;
};

export const submitAnswers = async (
  email: string,
  answers: Record<string, string[]>
): Promise<QuizSubmitResponseDTO> => {
  const response = await api.post("/quizzes/submit", { email, answers });

  return response.data.score;
};
