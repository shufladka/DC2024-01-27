package by.bsuir.publisher.model.dto.response;

import java.time.LocalDateTime;

public record TweetResponseTo(
        Long id,
        Long userId,
        String title,
        String content,
        LocalDateTime created,
        LocalDateTime modified
) {
}