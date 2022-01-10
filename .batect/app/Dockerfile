FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN mkdir -p /tools
COPY health-check.sh /tools/

HEALTHCHECK --interval=5s --retries=10 CMD /tools/health-check.sh
