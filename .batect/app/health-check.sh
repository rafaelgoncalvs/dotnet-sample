#!/usr/bin/env sh

set -e

HOST=${HOST:-localhost}
PORT=${PORT:-62118}

RESPONSE=$(curl "http://$HOST:$PORT/HealthCheck" --fail --show-error --silent || exit 1)

if [ "$RESPONSE" = "Healthy" ]; then
    echo "Response from service: $RESPONSE"
    exit 0
else
    echo "Unexpected response from service: $RESPONSE"
    exit 1
fi
