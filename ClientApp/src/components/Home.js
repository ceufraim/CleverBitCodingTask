import React, { useEffect, useState } from "react";
import gameMatchService from "../services/gameMatchService";
import authService from "./api-authorization/AuthorizeService";

export const Home = (props) => {
  const [isAuthenticated, setUserIsAuthenticated] = useState(false);
  const [pastMatches, setPastMatches] = useState([]);
  const [currentMatchScore, setCurrentMatchScore] = useState(-1);

  useEffect(() => {
    authService.isAuthenticated().then((res) => {
      setUserIsAuthenticated(res);
    });

    gameMatchService
      .getPastMatches()
      .then((res) => {
        setPastMatches(res.data);
      })
      .catch((err) => {
        alert(err);
      });

    gameMatchService
      .getCurrentMatchPlayerScore()
      .then((res) => {
        setCurrentMatchScore(res.data);
      })
      .catch((err) => {
        alert(err);
      });
  }, []);

  const play = async () => {
    const res = await gameMatchService.play();
    setCurrentMatchScore(res.data);
  };

  return (
    <div>
      {Home.name}
      <div>
        <h2>Game Match History</h2>
        <table className="table">
          <thead>
            <tr>
              <td>Number</td>
              <td>Expiry Date</td>
              <td>Participant ID</td>
              <td>Participant Score</td>
            </tr>
          </thead>
          <tbody>
            {pastMatches.map((m) => (
              <tr key={m.id}>
                <td>{m.id}</td>
                <td>{m.expiresAt}</td>
                <td>{m.winner?.participantId ?? "-"}</td>
                <td>{m.winner?.participantScore ?? "-"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {isAuthenticated && (
        <div>
          <h2>Current Match Score</h2>
          <div>
            {currentMatchScore === -1 ? (
              <button onClick={play}>Play</button>
            ) : (
              <span>Your current game score: {currentMatchScore}</span>
            )}
          </div>
        </div>
      )}
    </div>
  );
};
