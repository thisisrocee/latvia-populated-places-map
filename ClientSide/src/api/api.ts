import axios from "axios";
import { API_URL } from "../constants/url"

export const fetchAllPoints = async () => {
    try {
        const { data } = await axios.get(API_URL);
        return data;
    } catch (error) {
        console.log(error);
        return [];
    }
}
