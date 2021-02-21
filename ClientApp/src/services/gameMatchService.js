import Axios from "axios";
import authService from "../components/api-authorization/AuthorizeService";

class GameMatchService {
  getPastMatches = async () => {
    var token = await authService.getAccessToken();
    const config = {
      headers: { Authorization: `Bearer ${token}` },
    };
    return await Axios.get("/api/GameMatch/GetPastMatches", config);
  };

  getCurrentMatchPlayerScore = async () => {
    var token = await authService.getAccessToken();
    const config = {
      headers: { Authorization: `Bearer ${token}` },
    };
    return await Axios.get("/api/GameMatch/GetCurrentMatchPlayerScore", config);
  };

  play = async () => {
    var token = await authService.getAccessToken();
    const config = {
      headers: { Authorization: `Bearer ${token}` },
    };
    return await Axios.post("/api/GameMatch/Play", null, config);
  };
}

export default new GameMatchService();
