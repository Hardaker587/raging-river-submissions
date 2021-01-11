import Cookie from "cookie";
import JsCookie from "js-cookie";

export function getLoggedInUserFromCookie(req) {
  if (process.server && process.static && !req.headers.cookie) return;

  if (req.headers.cookie) {
    const parsedCookie = Cookie.parse(req.headers.cookie);
    const storedAccessToken = parsedCookie.access_token;

    if (storedAccessToken) {
      try {
        const base64Payload = storedAccessToken.split(".")[1];
        const decodedToken = JSON.parse(
          Buffer.from(base64Payload, "base64").toString()
        );

        return decodedToken;
      } catch (ex) {
        return null;
      }
    }
  }
}

export function persistCookie() {
  // check if user deleted cookie
  return !JsCookie.get("access_token");
}
