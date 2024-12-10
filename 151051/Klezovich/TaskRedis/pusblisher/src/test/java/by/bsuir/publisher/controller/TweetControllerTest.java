package by.bsuir.publisher.controller;

import by.bsuir.publisher.model.dto.request.TweetRequestTo;
import by.bsuir.publisher.model.dto.request.UserRequestTo;
import by.bsuir.publisher.model.dto.response.TweetResponseTo;
import io.restassured.response.Response;
import org.junit.jupiter.api.AfterAll;

public class TweetControllerTest extends AbstractControllerTest<TweetRequestTo, TweetResponseTo> {

    private static boolean isFKCreated = false;
    private static Long fkUserId;

    @Override
    protected String getRequestsMappingPath() {
        return "/tweets";
    }

    @Override
    protected TweetRequestTo getRequestTo() {
        createFKIfNotCreated();
        return new TweetRequestTo(null, fkUserId,
                "title" + random.nextInt(Integer.MAX_VALUE),
                "content" + random.nextInt(Integer.MAX_VALUE));
    }

    @Override
    protected TweetRequestTo getUpdatedRequestTo(TweetRequestTo requestTo, Long entityId) {
        return new TweetRequestTo(entityId,
                requestTo.userId(),
                requestTo.title() + random.nextInt(Integer.MAX_VALUE),
                requestTo.content() + random.nextInt(Integer.MAX_VALUE));
    }

    private void createFKIfNotCreated() {
        if (!isFKCreated) {
            UserRequestTo user = new UserRequestTo(null,
                    "login" + random.nextInt(Integer.MAX_VALUE),
                    "password" + random.nextInt(Integer.MAX_VALUE),
                    "firstame" + random.nextInt(Integer.MAX_VALUE),
                    "lastname" + random.nextInt(Integer.MAX_VALUE));
            Response userResponse = createEntityFK(user, "/users");
            fkUserId = getResponseId(userResponse);

            isFKCreated = true;
        }
    }

    @AfterAll
    public static void deleteFK() {
        if (isFKCreated) {
            deleteEntityFK(fkUserId, "/users");
        }
    }
}
