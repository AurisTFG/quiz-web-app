import React from "react";
import { AppBar, Toolbar, Typography, Box } from "@mui/material";
import NavButtons from "./NavButtons";

const Header: React.FC = () => {
  return (
    <AppBar
      position="static"
      sx={{
        background: "linear-gradient(to right,rgb(64, 112, 145), #9b59b6)",
      }}
    >
      <Toolbar>
        <Typography
          variant="h6"
          component="div"
          sx={{ flexGrow: 1, display: "flex", alignItems: "center" }}
        >
          <img src="/quiz.svg" alt="quiz icon" style={{ height: "25px", marginRight: "8px" }} />
          Quiz App
        </Typography>
        <Box sx={{ flexGrow: 1, mr: 13, display: "flex" }}>
          <NavButtons />
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
