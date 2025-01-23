import React from "react";
import { AppBar, Toolbar, Typography, Button, Box } from "@mui/material";
import { Link } from "react-router-dom";
import { useLocation } from "react-router-dom";

const Header: React.FC = () => {
  const location = useLocation();
  const isActive = (path: string) => location.pathname === path;

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography
          variant="h6"
          component="div"
          sx={{ flexGrow: 1, display: "flex", alignItems: "center" }}
        >
          <img
            src="/quiz.svg"
            alt="quiz icon"
            style={{ height: "20px", marginRight: "8px", color: "white" }}
          />
          Quiz App
        </Typography>
        <Box sx={{ flexGrow: 1, mr: 10, display: { xs: "none", md: "flex" } }}>
          <Button
            color="inherit"
            component={Link}
            to="/"
            sx={{
              mr: 1,
              textDecoration: isActive("/") ? "underline" : "none",
              fontSize: "1.20rem",
            }}
          >
            Quiz
          </Button>
          <Button
            color="inherit"
            component={Link}
            to="/highscores"
            sx={{
              mr: 1,
              textDecoration: isActive("/highscores") ? "underline" : "none",
              fontSize: "1.20rem",
            }}
          >
            High Scores
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
