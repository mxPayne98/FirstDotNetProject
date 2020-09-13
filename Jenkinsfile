#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                dotnet build FirstSolution.sln
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('SonarQube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    sh """
                    #!/bin/bash
                    dotnet build-server shutdown
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll begin /k:"FirstCoreProject" /d:sonar.host.url=http://172.18.0.4:9000 /d:sonar.login="e48ea67ef56e7fe28b84c6d72abe4ff3f43538c5" /d:sonar.cs.opencover.reportsPaths="FirstCoreProject/coverage.opencover.xml" /d:sonar.coverage.exclusions="FirstCoreProject/Test1.cs"
                    dotnet build FirstSolution.sln
                    dotnet /sonar-scanner/SonarScanner.MSBuild.dll end /d:sonar.login="e48ea67ef56e7fe28b84c6d72abe4ff3f43538c5"
                    """
                }
            }
        }
        stage("Quality Gate") {
            steps {
              timeout(time: 5, unit: 'MINUTES') {
                waitForQualityGate abortPipeline: true
              }
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet run
                """
            }
        }
    }
}